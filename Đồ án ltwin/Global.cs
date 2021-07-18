using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_ltwin
{
    class Global
    {
        public static int GlobalUserId { get; private set; }
        public static void SetGlobalUserId(int userId)
        {
            GlobalUserId = userId;
        }
        public static int check { get; set; }
        public static string ID { get; private set; }
        public static void SetId(string userId)
        {
            ID = userId;
        }
    }
}
