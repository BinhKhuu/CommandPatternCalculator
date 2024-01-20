using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternCalculator.Interfaces
{
    public interface ICommand
    {
        double Operand {get;}
        void Execute();
        void Undo();
    }
}
