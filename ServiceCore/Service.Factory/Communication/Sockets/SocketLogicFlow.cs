using Service.Core;
using Service.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Factory.Communication.Sockets
{
    public class SocketLogicFlow : BaseLogicFlow
    {
        public SocketLogicFlow(LogicFlowModel logic)
        {
            base._logics.Add(logic);
        }

        public SocketLogicFlow(LogicFlowModel[] logics)
        {
            base._logics.AddRange(logics);
        }
    }
}
