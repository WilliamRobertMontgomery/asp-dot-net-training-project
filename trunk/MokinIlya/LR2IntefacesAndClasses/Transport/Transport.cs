using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOVING
{
    public class Transport:ITransport
    {
        public Transport (int x, int y)
        {
            _x = x;
            _y = y;
            Console.WriteLine("Объявлен неизвестный транспорт, класса Transport, с координатами ({0}, {1})", x,y);
        }

        public Transport()
        {
            _x = 0;
            _y = 0;
            Console.WriteLine("Объявлен неизвестный транспорт, класса Transport, с координатами ({0}, {1})", 0, 0);
        }

        private int _x;

        private int _y;

        public void MoveUpTo(int delt)
        {
            _y += delt;
            Console.WriteLine("Координаты транспорта смещены вверх на {0}, текущие координаты ({1}, {2})", delt, _x, _y);
            return;
            throw new NotImplementedException();
        }

        public void MoveDownTo(int delt)
        {
            _y -= delt;
            Console.WriteLine("Координаты транспорта смещены вниз на {0}, текущие координаты ({1}, {2})", delt, _x, _y);
            return;
            throw new NotImplementedException();
        }

        public void MoveLeftTo(int delt)
        {
            _x -= delt;
            Console.WriteLine("Координаты транспорта смещены влево на {0}, текущие координаты ({1}, {2})", delt, _x, _y);
            return;
            throw new NotImplementedException();
        }

        public void MoveRightTo(int delt)
        {
            _x += delt;
            Console.WriteLine("Координаты транспорта смещены вправо на {0}, текущие координаты ({1}, {2})", delt, _x, _y);
            return;
            throw new NotImplementedException();
        }
    }
}
