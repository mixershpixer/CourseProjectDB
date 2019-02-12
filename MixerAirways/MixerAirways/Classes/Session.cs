using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixerAirways.Classes
{
    public class Session
    {
        public int user_id;
        public int account_type;
        public int is_active;
        public Session(int user_id, int account_type, int is_active)
        {
            this.user_id = user_id;
            this.account_type = account_type;
            this.is_active = is_active;
        }
    }
}
