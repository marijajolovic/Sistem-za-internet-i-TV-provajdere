using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.AppLogic.Interfaces {
    public interface IPrototype<T> {

        T clone();

    }
}
