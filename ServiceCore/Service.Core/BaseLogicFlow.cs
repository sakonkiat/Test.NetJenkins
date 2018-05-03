using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{
    public abstract class BaseLogicFlow
    {
        protected List<LogicFlowModel> _logics = new List<LogicFlowModel>();

        public List<LogicFlowModel> Logics
        {
            get { return _logics.OrderBy(x => x.Seq).ToList(); }
        }

        public int[] Seqs
        {
            get { return _logics.Select(x => x.Seq).OrderBy(x => x).ToArray(); }
        }

        public void Add(LogicFlowModel logic)
        {
            Logics.Add(logic);
        }

        public void Add(LogicFlowModel[] logics)
        {
            Logics.AddRange(logics);
        }

        public void Remove(LogicFlowModel logic)
        {
            Logics.Remove(logic);
        }

        public void Remove(int seq)
        {
            Logics.RemoveAll(x => x.Seq == seq);

        }

        public virtual void Execute()
        {
            foreach (var item in Logics)
            {
                while (!item.Logic.Process()) { }
            }
        }
    }
}
