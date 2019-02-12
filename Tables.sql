use AeroDB;

create table Airports(
	airport_code int identity not null,
	airport_name nvarchar(50) not null,
	city nvarchar(50),
	constraint [PK_Airport_code_Airports] primary key clustered (airport_code ASC)
);

create table Aircrafts(
	aircraft_code int identity not null,
	model nvarchar(50) not null,
	a_class_seats int not null,
	b_class_seats int not null,
	c_class_seats int not null,
	constraint [PK_Aircraft_code_Aircrafts] primary key clustered (aircraft_code ASC)
);

create table Flights(
	flight_id int identity not null,
	departure_time int not null,
	departure_airport int not null,
	aircraft_code int not null,
	arrival_time int not null,
	arrival_airport int not null,
	constraint [PK_Flight_id_Flights] primary key clustered (flight_id ASC),
	constraint FK_Departure_airport_Flights foreign key (departure_airport) references Airports(airport_code),
	constraint FK_Aircraft_code_Flights foreign key (aircraft_code) references Aircrafts(aircraft_code),
	constraint FK_Arrival_airport_Flights foreign key (arrival_airport) references Airports(airport_code)
);

create table Bookings(
	book_ref int not null,
	passenger_id int not null,
	book_date int not null,
	flight_id int not null,
	seat_no int not null,
	fare_condition nvarchar(50) not null,
	price int not null,
	is_active int not null,
	constraint [PK_Book_ref_Bookings] primary key clustered (book_ref ASC),
	constraint FK_Passenger_id_Bookings foreign key (passenger_id) references Users(user_id),
	constraint FK_Flight_id_Bookings foreign key (flight_id) references Flights(flight_id)
);

create table Tickets(
	ticket_no int identity not null,
	passenger_id int not null,
	flight_id int not null,
	constraint [PK_Ticket_no_Tickets] primary key clustered (ticket_no ASC),
	constraint FK_Flight_id_Tickets foreign key (flight_id) references Flights(flight_id),
);
--
create table Seats(
	aircraft_code int not null,
	free_a_class_seats int not null,
	free_b_class_seats int not null,
	free_c_class_seats int not null,
	constraint FK_Aircraft_code_Seats foreign key (aircraft_code) references Aircrafts(aircraft_code)
);

create table Sessions(
	user_id int not null,
	account_type int not null,
	is_active int,
	constraint [PK_User_id_Sessions] primary key clustered (user_id ASC),
	constraint FK_User_id_Sessions foreign key (user_id) references Users(user_id),
	constraint FK_Account_type_Sessions foreign key (account_type) references Account_types(code)
);

create table Account_types(
	code int not null,
	type nvarchar(50),
	constraint [PK_Code_Account_types] primary key clustered (code ASC)
);

create table Users(
	user_id int identity not null,
	username nvarchar(50) not null,
	password nvarchar(50) not null,
	contact_data nvarchar(50) not null,
	account_type int not null,
	constraint [PK_User_id_Users] primary key clustered (user_id ASC),
	constraint FK_Account_type_Users foreign key (account_type) references Account_types(code)
);

create table Notifications(
	notification_id int identity not null,
	user_id int not null,
	flight_id int not null,
	not_code int not null,
	constraint [PK_Notification_id_Notifications] primary key clustered (notification_id ASC),
	constraint FK_User_id_Users foreign key (user_id) references Users(user_id)
);

begin 
declare 
@i int = 0,
@time int,
@dep int,
@arr int
while @i < 100000
begin
set @time = ROUND(((1546300800 - 1543306489 - 1) * RAND() + 1543306489), 0)
set @dep = ROUND(((15 - 1 - 1) * RAND() + 1), 0)
set @arr = ROUND(((15 - 1 - 1) * RAND() + 1), 0)
while (@dep = @arr) set @arr = ROUND(((15 - 1 - 1) * RAND() + 1), 0)
insert into Flights(departure_time, departure_airport, aircraft_code, arrival_time, arrival_airport) 
values (@time, @dep, 
		ROUND(((11 - 1 - 1) * RAND() + 1), 0), 
		@time + ROUND(((45000  - 20000 - 1) * RAND() + 20000), 0), @arr)
set @i = @i + 1	
end
end	

begin 
declare 
@start datetime = GETDATE()
select f.flight_id, 
	format(DATEADD(second, f.departure_time, '1970/01/01 00:00'), 'dd.MM.yyyy HH.mm') as departure_time, 
	a.airport_name as departure_airport, a.city as departure_city, ac.model,
	format(DATEADD(second, f.arrival_time, '1970/01/01 00:00'), 'dd.MM.yyyy HH.mm')  as arrival_time,
	ap.airport_name  as arrival_airport, ap.city as arrival_city
		from Flights f 
			inner join Airports a
				on a.airport_code = f.departure_airport
			inner join Airports ap
				on ap.airport_code = f.arrival_airport
			inner join Aircrafts ac
				on ac.aircraft_code = f.aircraft_code
	order by departure_time asc;
declare @end datetime = GETDATE()
	SELECT DATEDIFF(ms,@start,@end) AS [Duration in miliseconds]
end	