using library.AppLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Memento {
    internal class Snapshot {

        private Stack<ConcreteCommand> commandsUndo;
        private Stack<ConcreteCommand> commandsRedo;
        private Database.Database instance;
        private IAppLogicFacade appLogic;

        public Snapshot(Database.Database instance, IAppLogicFacade aLogic) {
            this.commandsUndo = new Stack<ConcreteCommand>();
            this.commandsRedo = new Stack<ConcreteCommand>();
            this.instance = instance;
            this.appLogic = aLogic;
        }

        public void CreateSnapshot(Dictionary<string, object> parameters) {
            this.commandsUndo.Push(new ConcreteCommand(parameters, instance));
        }

        public void RestoreSnapshot() {
            if(commandsUndo.Count == 0) return;

            ConcreteCommand command = commandsUndo.Pop();
            command.undo(appLogic);
            commandsRedo.Push(command);
        }

        public void RedoSnapshot() {
            if(commandsRedo.Count == 0) return;

            ConcreteCommand command = commandsRedo.Pop();
            command.redo(appLogic);
            commandsUndo.Push(command);
        }

    }
}
