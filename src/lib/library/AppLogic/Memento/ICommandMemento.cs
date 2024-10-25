using library.AppLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Memento {
    internal interface ICommandMemento {

        void undo(IAppLogicFacade aLogic);
        void redo(IAppLogicFacade aLogic);
    }
}
