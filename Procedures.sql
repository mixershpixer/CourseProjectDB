use AeroDB;
--USER
alter procedure user_auth @username nvarchar(50), @password nvarchar(50)
as 
	if (select count(*) from Users where username = @username and password = @password) = 1
	begin
		declare @user_id int = (select user_id from Users where username = @username)
		declare @acc_type int = (select account_type from Users where username = @username)
		if (select count(*) from Sessions where user_id = @user_id) = 0
		insert into Sessions(user_id, account_type, is_active) values(@user_id, @acc_type, 1)
		else update Sessions set is_active = 1 where user_id = @user_id
		select u.user_id, u.account_type, s.is_active, u.username, u.contact_data from Users u inner join Sessions s on u.user_id = s.user_id where u.username = @username
	end
	else select 0
go

alter procedure user_reg @username nvarchar(50), @password nvarchar(50), @contact_data nvarchar(50)
as
	if(select count(*) from Users where username = @username) != 0 select -5
	else
	begin
		declare @acc_type int = 1
		insert into Users(username, password, contact_data, account_type) values (@username, @password, @contact_data, @acc_type);
		declare @user_id int = (select user_id from Users where username = @username)
		insert into Sessions(user_id, account_type, is_active) values(@user_id, @acc_type, 1)
		select u.user_id, u.account_type, s.is_active, u.username, u.contact_data from Users u inner join Sessions s on u.user_id = s.user_id where u.username = @username
	end
go

exec user_reg @username = 'admin', @password = 'admin', @contact_data = 'admin.admin@mail.ru';
exec user_reg @username = 'mixer', @password = '11111', @contact_data = 'mixer.shpixer@mail.ru';
exec user_reg @username = 'ivan', @password = '11111', @contact_data = 'ivanchik@mail.ru';
exec user_reg @username = 'petro', @password = '11111', @contact_data = 'petros@mail.ru';
exec user_reg @username = 'jopa', @password = '11111', @contact_data = 'jopa@mail.ru';

alter procedure user_logout @user_id int
as
	if(select count(*) from Sessions where user_id = @user_id and is_active = 1) = 0 select 0
	else update Sessions set is_active = 0 where user_id = @user_id 
go
exec user_logout 4;

alter procedure user_change @user_id int, @username nvarchar(50), @password nvarchar(50), @contact_data nvarchar(50)
as
	if(select count(*) from Users u 
	inner join Sessions s on u.user_id=s.user_id 
	where username = @username and s.is_active = 0) > 0 select 0
	else begin
	update Users set username = @username, password = @password, contact_data = @contact_data where user_id = @user_id
	select 1 end
go

exec user_change 1, 'mixer', '11111', 'mixer@mail.ru';

alter procedure user_del @user_id int
as
	if(select count(*) from Users where user_id = @user_id) != 0
		if(select count(*) from Bookings where passenger_id = @user_id) != 0
		delete from Users where user_id = @user_id
		else THROW 56000, 'You cant delete user while he has an active bookings', 1;
	else THROW 56000, 'There are no users with that ID', 1;
go

exec user_auth 'admin','admin'

--AIRCRAFT

--new_aircraft
create procedure new_aircraft @model nvarchar(50), @a_class_seats int, @b_class_seats int, @c_class_seats int
as
declare @aircraft_code int
if((select count(*) from Aircrafts where model = @model and a_class_seats = @a_class_seats) = 0)
begin
	insert into Aircrafts(model, a_class_seats, b_class_seats, c_class_seats) 
	values (@model, @a_class_seats, @b_class_seats, @c_class_seats)

	set @aircraft_code = (select aircraft_code from Aircrafts where model = @model and a_class_seats = @a_class_seats)

	insert into Seats(aircraft_code, free_a_class_seats, free_b_class_seats, free_c_class_seats) 
	values (@aircraft_code, @a_class_seats, @b_class_seats, @c_class_seats)
end
else THROW 55000, 'The same aircraft is already exist', 1; 
go

exec new_aircraft 'Airbus-A340', 150, 250, 300;
exec new_aircraft 'Èë-62', 30, 50, 110;
exec new_aircraft 'SSJ-100', 50, 100, 100;
exec new_aircraft 'Boeing-757', 50, 100, 100;
exec new_aircraft 'Airbus-À320', 30, 50, 100;
exec new_aircraft 'Airbus-À380', 200, 300, 500;
exec new_aircraft 'Òó-154', 20, 50, 80;
exec new_aircraft 'Lockheed-Galaxy', 50, 80, 140;
exec new_aircraft 'Àí-124', 70, 150, 100;
exec new_aircraft 'Àí-255', 40, 70, 110;

--change_aircraft
alter procedure change_aircraft @aircraft_code int,  @model nvarchar(50), @a_class_seats int, @b_class_seats int, @c_class_seats int
as	
	if((select count(*) from Flights where aircraft_code = @aircraft_code) = 0)
	begin 
	update Aircrafts set model = @model, a_class_seats = @a_class_seats, b_class_seats = @b_class_seats, c_class_seats = @c_class_seats 
		where aircraft_code = @aircraft_code
	update Seats set free_a_class_seats = @a_class_seats, free_b_class_seats = @b_class_seats, free_c_class_seats = @c_class_seats 
		where aircraft_code = @aircraft_code
	end
	else THROW 56000, 'You cannot change the information while the aircraft is in the active flight', 1;
go

--del_aircraft
alter procedure del_aircraft @aircraft_code int
as
	if((select count(*) from Flights where aircraft_code = @aircraft_code) = 0)
	begin 
	delete from Seats where aircraft_code = @aircraft_code
	delete from Aircrafts where aircraft_code = @aircraft_code
	end else THROW 56000, 'You cannot delete this aircraft while it is in the active flight', 1;
go
drop procedure del_aircraft;
exec del_aircraft @aircraft_code = 10;

--FLIGHTS

alter procedure new_flight @departure_time nvarchar(50), @departure_airport int, @aircraft_code int, @arrival_time nvarchar(50), @arrival_airport int
as
	if(select count(*) from Airports where airport_code = @departure_airport) != 0
		if(select count(*) from Airports where airport_code = @arrival_airport) != 0
			if(select count(*) from Aircrafts where aircraft_code = @aircraft_code) != 0
			begin
				insert into Flights(departure_time, departure_airport, aircraft_code, arrival_time, arrival_airport) 
				values (CONVERT(INT, DATEDIFF(SECOND, '19700101', @departure_time)), 
				@departure_airport, @aircraft_code, CONVERT(INT, DATEDIFF(SECOND, '19700101', @arrival_time)), @arrival_airport)
			end
			else THROW 70000, 'Incorrect aircraft', 1;
		else THROW 71000, 'Incorrect arrival airport', 1;
	else THROW 72000, 'Incorrect departure airport', 1;
go

exec new_flight @departure_time = '2018-11-24 11:25', @departure_airport = 2, @aircraft_code = 1, @arrival_time = '2018-11-24 20:25', @arrival_airport = 2;

alter procedure moder_change_flight_status @user_id int, @flight_id int 
as 
	if (select count(*) from Sessions where user_id = @user_id and account_type = 0) != 0
	begin
		update Flights set departure_time = departure_time * (-1) where flight_id = @flight_id
		select 1
	end
	else select 0
go


exec moder_change_flight_status 1, 93001;


create trigger updated_flights on Flights after update
as
begin
	declare @flight_id int 
	declare @user_id int = 0
	declare @check int = 0
	select @flight_id = flight_id from inserted
	set @user_id = (select passenger_id from Bookings where flight_id = @flight_id)
	if(select departure_time from Flights where flight_id = @flight_id) > 0 set @check = 1
	if @user_id != 0
	begin
		if (select count(*) from Notifications where user_id = @user_id and flight_id = @flight_id) = 0 
		begin
			insert into Notifications (user_id, flight_id, not_code) values (@user_id, @flight_id, @check)
		end
		else update Notifications set not_code = @check where user_id = @user_id and flight_id = @flight_id
	end
end 


alter procedure view_all_notifications @user_id int
as
	if (select count(*) from Notifications where user_id = @user_id) != 0
		select 1, format(DATEADD(second, f.departure_time, '1970/01/01 00:00'), 'dd.MM.yyyy HH.mm'), ap1.city, ap2.city, n.not_code
			from Flights f 
				inner join Notifications n
					on f.flight_id = n.flight_id
				inner join Airports ap1
					on ap1.airport_code = f.departure_airport
				inner join Airports ap2
					on ap2.airport_code = f.arrival_airport
		order by departure_time asc;
	else select 0
go

alter procedure del_flight @flight_id int
as
	if(select count(*) from Bookings where flight_id = @flight_id) = 0
	delete from Flights where flight_id = @flight_id
	else THROW 71000, 'You can not delete Active flight with bookings', 1;
go


exec view_all_notifications 3;

delete from Notifications where notification_id > 0;

exec choose_flight @departure_date = '21.12', @departure_city = 'Dallas', @arrival_city = 'Paris';

alter procedure choose_flight @departure_date nvarchar(50), @departure_city nvarchar(50), @arrival_city nvarchar(50)
as
	declare 
	@i int = 1,
	@x int = 1,
	@z int = 1,
	@y int = 1,
	@p int = 1,
	@dc nvarchar(50),
	@ac nvarchar(50),
	@city nvarchar(50),
	@f_id int = 0,
	@start datetime = GETDATE()
	declare @depcity table(city nvarchar(50))
	declare @arrcity table(city nvarchar(50))
	declare @dc_code table(num int identity, city_code int)
	declare @ac_code table(num int identity, city_code int)
	declare @need_flight table(num int identity, id int)
	declare @last_need_flight table(num int identity, id int)

	while @i <= (select count(*) from Airports)
	begin
		set @city = (select city from Airports where Airports.airport_code = @i)
		if @departure_city like '%'+@city+'%'
			insert into @dc_code(city_code) values (@i)
		if @arrival_city like '%'+@city+'%'
			insert into @ac_code(city_code) values (@i)
		set @i = @i + 1
	end
	if (select count(*) from @dc_code) = 0 THROW 60000, 'No planes fly from this city', 1;
	if (select count(*) from @ac_code) = 0 THROW 61000, 'No planes fly to this city', 1;
	set @i = 1
	insert into @need_flight (id) select flight_id from Flights f 
				inner join @dc_code d on f.departure_airport = d.city_code 
				inner join @ac_code a on f.arrival_airport = a.city_code
				where f.departure_time > 0

	if (select count(*) from @need_flight) = 0 THROW 62000, 'There are no flights beetwen this cities', 1;

	insert into @last_need_flight (id) select flight_id from Flights f 
				inner join @need_flight n on f.flight_id = n.id 
				where (format(DATEADD(second, f.departure_time, '1970/01/01 00:00'), 'dd.MM')) = @departure_date 
	
	if(select count(*) from @last_need_flight) != 0
		select f.flight_id, format(DATEADD(second, f.departure_time, '1970/01/01 00:00'), 'dd.MM.yyyy HH.mm') as departure_time, 
		a.airport_name as departure_airport, a.city as departure_city, ac.model,
		format(DATEADD(second, f.arrival_time, '1970/01/01 00:00'), 'dd.MM.yyyy HH.mm')  as arrival_time,
		ap.airport_name  as arrival_airport, ap.city as arrival_city
			from Flights f 
				inner join @last_need_flight l
					on f.flight_id = l.id
				inner join Airports a
					on a.airport_code = f.departure_airport
				inner join Airports ap
					on ap.airport_code = f.arrival_airport
				inner join Aircrafts ac
					on ac.aircraft_code = f.aircraft_code
		order by departure_time asc;
	else select 0
	declare @end datetime = GETDATE()
	SELECT DATEDIFF(ms,@start,@end) AS [Duration in microseconds]
go




--BOOKINGS
create sequence book_ref_seq
  start with 1
  increment by 1;

alter procedure new_book @passenger_id int, @fare_condition nvarchar(50), @flight_id int
as
	declare
	@a datetime = CURRENT_TIMESTAMP,
	@price int,
	@book_ref int,
	@book_date int,
	@total_seats int,
	@total_seats_count int,
	@total_free_seats_count int,
	@seat_no int
	set @book_ref = CAST(FORMAT(@a, 'ddmmss') AS int) + next value for book_ref_seq
	set @book_date = DATEDIFF(s, '1970-01-01', CURRENT_TIMESTAMP)
	set @total_seats = (select a_class_seats + b_class_seats + c_class_seats from Aircrafts 
						inner join Flights on Aircrafts.aircraft_code = Flights.aircraft_code 
						where flight_id = @flight_id )

	if @total_seats != 0
		if((select count(*) from Bookings where passenger_id = @passenger_id and flight_id = @flight_id) = 0)
		begin
			if @fare_condition = 'A'
				begin
					set @price = ROUND(((300 - 200 - 1) * RAND() + 200), 0) * 10
					set @total_seats_count = (select a_class_seats from Aircrafts 
					inner join Flights on Aircrafts.aircraft_code = Flights.aircraft_code where flight_id = @flight_id)
					set @total_free_seats_count = (select free_a_class_seats from ((Seats
					inner join Aircrafts on Seats.aircraft_code = Aircrafts.aircraft_code)
					inner join Flights on Aircrafts.aircraft_code = Flights.aircraft_code) 
					where flight_id = @flight_id)
					if @total_free_seats_count != 0
					begin
						update Seats set free_a_class_seats = free_a_class_seats - 1 from ((Seats
						inner join Aircrafts on Seats.aircraft_code = Aircrafts.aircraft_code)
						inner join Flights on Aircrafts.aircraft_code = Flights.aircraft_code) where flight_id = @flight_id
						set @seat_no = @total_seats_count - @total_free_seats_count + 1
					end
					else THROW 53000, 'There are no A-class places, please choose another', 1;
				end
				else 
					if @fare_condition = 'B'
						begin
							set @price = ROUND(((200 - 100 - 1) * RAND() + 100), 0) * 10
							set @total_seats_count = (select b_class_seats from Aircrafts 
							inner join Flights on Aircrafts.aircraft_code = Flights.aircraft_code where flight_id = @flight_id)
							set @total_free_seats_count = (select free_b_class_seats from ((Seats
							inner join Aircrafts on Seats.aircraft_code = Aircrafts.aircraft_code)
							inner join Flights on Aircrafts.aircraft_code = Flights.aircraft_code) 
							where flight_id = @flight_id)
							if @total_free_seats_count != 0
							begin
								update Seats set free_b_class_seats = free_b_class_seats - 1 from ((Seats
								inner join Aircrafts on Seats.aircraft_code = Aircrafts.aircraft_code)
								inner join Flights on Aircrafts.aircraft_code = Flights.aircraft_code) where flight_id = @flight_id
								set @seat_no = @total_seats_count - @total_free_seats_count + 1
							end
							else THROW 53000, 'There are no B-class places, please choose another', 1;
						end
						else 
						if @fare_condition = 'C'
							begin
								set @price = ROUND(((100 - 50 - 1) * RAND() + 50), 0) * 10
								set @total_seats_count = (select c_class_seats from Aircrafts 
								inner join Flights on Aircrafts.aircraft_code = Flights.aircraft_code where flight_id = @flight_id)
								set @total_free_seats_count = (select free_c_class_seats from ((Seats
								inner join Aircrafts on Seats.aircraft_code = Aircrafts.aircraft_code)
								inner join Flights on Aircrafts.aircraft_code = Flights.aircraft_code) 
								where flight_id = @flight_id)
								if @total_free_seats_count != 0
								begin
									update Seats set free_c_class_seats = free_c_class_seats - 1 from ((Seats
									inner join Aircrafts on Seats.aircraft_code = Aircrafts.aircraft_code)
									inner join Flights on Aircrafts.aircraft_code = Flights.aircraft_code) where flight_id = @flight_id
									set @seat_no = @total_seats_count - @total_free_seats_count + 1
								end
								else THROW 53000, 'There are no C-class places, please choose another', 1;
							end
						else THROW 52000, 'Incorrect fare condition type', 1;
		end
		else THROW 54000, 'You already have a book on this flight', 1;
	else THROW 57000, 'There are no free places on this flight', 1;
	insert into Bookings(book_ref, passenger_id, book_date, flight_id, seat_no, fare_condition, price, is_active)
		values(@book_ref, @passenger_id, @book_date, @flight_id, @seat_no, @fare_condition, @price, 1)
go

exec new_book @passenger_id = 1, @fare_condition = 'C', @flight_id = 93001;

alter procedure revoke_book @passenger_id int, @flight_id int
as 
	declare 
	@fare_condition nvarchar(50)
	set @fare_condition = (select fare_condition from Bookings where passenger_id = @passenger_id and flight_id = @flight_id)
	if @fare_condition = 'A'
		begin
			update Seats set free_a_class_seats = free_a_class_seats + 1 from ((Seats
			inner join Aircrafts on Seats.aircraft_code = Aircrafts.aircraft_code)
			inner join Flights on Aircrafts.aircraft_code = Flights.aircraft_code) where flight_id = @flight_id
		end
		else 
		if @fare_condition = 'B'
			begin
				update Seats set free_b_class_seats = free_b_class_seats + 1 from ((Seats
				inner join Aircrafts on Seats.aircraft_code = Aircrafts.aircraft_code)
				inner join Flights on Aircrafts.aircraft_code = Flights.aircraft_code) where flight_id = @flight_id
			end
			else 
			if @fare_condition = 'C'
				begin
					update Seats set free_c_class_seats = free_c_class_seats + 1 from ((Seats
					inner join Aircrafts on Seats.aircraft_code = Aircrafts.aircraft_code)
					inner join Flights on Aircrafts.aircraft_code = Flights.aircraft_code) where flight_id = @flight_id
				end
	delete from Bookings where passenger_id = @passenger_id and flight_id = @flight_id
go
exec revoke_book 3, 1;
exec revoke_book 4, 5;

alter procedure view_my_books @passenger_id int
as 
	if(select count(*) from Bookings where passenger_id = @passenger_id) = 0 select 0
	else 
	select b.book_ref,
	format(DATEADD(second, b.book_date, '1970/01/01 00:00'), 'HH.mm dd.MM.yyyy'), 
	ap1.airport_name, ap1.city, 
	format(DATEADD(second, f.departure_time, '1970/01/01 00:00'), 'HH.mm dd.MM.yyyy'), 
	ac.model, ap2.airport_name, ap2.city,
	format(DATEADD(second, f.arrival_time, '1970/01/01 00:00'), 'HH.mm dd.MM.yyyy'),
	b.seat_no, b.fare_condition, b.price, f.flight_id
	from Bookings b 
	inner join Flights f on b.flight_id = f.flight_id 
	inner join Aircrafts ac on f.aircraft_code = ac.aircraft_code
	inner join Airports ap1 on ap1.airport_code = f.departure_airport
	inner join Airports ap2 on ap2.airport_code = f.arrival_airport
	where passenger_id = @passenger_id and b.is_active = 1
	order by b.book_date desc
go

exec view_my_books 7;
select * from Users;
--TICKETS
exec buy_ticket @user_id = 7, @flight_id = 93001;
exec view_my_tickets 1;

alter procedure buy_ticket @passenger_id int, @flight_id int
as
	declare
	@book_ref int
	set @book_ref = (select book_ref from Bookings where passenger_id = @passenger_id and flight_id = @flight_id and is_active = 1)
	if @book_ref != 0
	begin
		insert into Tickets(passenger_id, flight_id) values (@passenger_id, @flight_id)
		update Bookings set is_active = 0 where passenger_id = @passenger_id and flight_id = @flight_id
	end
	else 
		THROW 50000, 'You have no active booking for this flight', 1;
go

alter procedure view_my_tickets @passenger_id int
as 
	if(select count(*) from Tickets where passenger_id = @passenger_id) = 0 select 0
	else 
	select t.ticket_no,
	format(DATEADD(second, b.book_date, '1970/01/01 00:00'), 'dd.MM.yyyy'), 
	ap1.airport_name, ap1.city, 
	format(DATEADD(second, f.departure_time, '1970/01/01 00:00'), 'HH.mm dd.MM.yyyy'), 
	ac.model, ap2.airport_name, ap2.city,
	format(DATEADD(second, f.arrival_time, '1970/01/01 00:00'), 'HH.mm dd.MM.yyyy'),
	b.seat_no, b.fare_condition, b.price, f.flight_id
	from Tickets t
	inner join Bookings b on t.flight_id = b.flight_id and t.passenger_id = b.passenger_id
	inner join Flights f on b.flight_id = f.flight_id 
	inner join Aircrafts ac on f.aircraft_code = ac.aircraft_code
	inner join Airports ap1 on ap1.airport_code = f.departure_airport
	inner join Airports ap2 on ap2.airport_code = f.arrival_airport
	where t.passenger_id = @passenger_id
	order by t.ticket_no desc
go

alter procedure return_ticket_back @passenger_id int, @flight_id int
as
	if(select count(*) from Tickets where passenger_id = @passenger_id and flight_id = @flight_id) = 0 select 0
	else 
		delete from Tickets where passenger_id = @passenger_id and flight_id = @flight_id
		delete from Bookings where passenger_id = @passenger_id and flight_id = @flight_id
go
exec return_ticket_back 2, 90381;

select * from Tickets;
select * from Bookings;
select * from Notifications;


delete from Bookings where passenger_id = 1;



create procedure Select_Count_Aircrafts @dep_air int, @arr_air int
as
	select departure_time, departure_airport, aircraft_code, arrival_time, arrival_airport from Flights where departure_airport = @dep_air and arrival_airport = @arr_air
go


create procedure Count_Flights @start_date nvarchar(50), @end_date nvarchar(50)
as
select departure_time, departure_airport, aircraft_code from Flights where (format(DATEADD(second, departure_time, '1970/01/01 00:00'), 'dd.MM')) between @start_date and @end_date
go

exec Count_Flights '12.12','13.12'

alter procedure AircraftsInfo
as
select model, (a_class_seats + b_class_seats + c_class_seats) as total_seats from Aircrafts
go

exec AircraftsInfo;


create procedure Insert_Xml
as 
begin
	declare @xml xml
	select @xml = P
	from openrowset (bulk 'D:\Study\3_COURSE\5_SEMESTR\CPDB\xml\Users.xml', single_blob) as service(P)
	insert into Users (username, password, contact_data, account_type)
	select  x.value('username[1]', 'nvarchar(50)') as username,
			x.value('password[1]', 'nvarchar(50)') as password,
			x.value('contact_data[1]', 'nvarchar(50)') as contact_data,
			x.value('account_type[1]', 'int') as account_type
	from @xml.nodes('/Users/User') XmlData(x)
end;


create procedure Export_Xml
as
	select * from Users
	for xml path('user'), root('USERS');
go

exec Insert_Users_Xml;
exec Export_Users_Xml;