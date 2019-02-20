using System;
using System.Collections.Generic;

namespace RestFull0aNuvem.Model.Context
{
    public class Messages
    {
        public string StatusCodigo { get; set; }
        public string StatusDescricao { get; set; }
    }

    public class MessagesEspecifica
    {
        public Messages messages { get; set; }
        public string[] MsgeEpecifica { get; set; }
    }

}
