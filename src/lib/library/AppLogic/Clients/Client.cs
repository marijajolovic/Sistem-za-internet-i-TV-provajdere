using library.AppLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Clients {
    public class Client : IPrototype<Client> {

        private int clientID;
        private string username;
        private string firstName;
        private string lastName;

        public int ClientID { get { return clientID; } }
        public string Username { get { return username; } set {  username = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }

        public Client(int clientID, string username, string firstName, string lastName) {
            this.clientID = clientID;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        #region PROTOTYPE IMPLEMENTATION
        public Client clone() {
            return new Client(this);
        }

        public Client(Client c) {
            this.clientID = c.clientID;
            this.username = c.username;
            this.firstName = c.firstName;
            this.lastName = c.lastName;
        }
        #endregion



    }
}
