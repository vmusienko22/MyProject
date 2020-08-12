using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    /// <summary>
    /// Класс содержащий методы предназначеные для управления аккаунтами
    /// (Добавление и удаление Администраторов и Пользователей)
    /// </summary>
    class Owner
    {
        public Owner()
        {
            AuthotizationValidator.CheckPassword("");
        }
    }
}
