using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOVING
{
    public class Truck : ITruck
    {
        public Truck(string nameTruck, int x, int y)
        {
            _Name = nameTruck;
            _x = x;
            _y = y;
            _frontRigthDoor = true; //doors closed
            _frontLeftDoor = true;
            _backRigthDoor = true;
            _backLeftDoor = true;
            _start = false;
            Console.WriteLine("Объявлен грузовик {0}, класса Truck, начальные координаты ({1}, {2})", _Name, x, y);
        }

        public Truck()
        {
            _Name = "";
            _x = 0;
            _y = 0;
            _frontRigthDoor = true; //doors closed
            _frontLeftDoor = true;
            _backRigthDoor = true;
            _backLeftDoor = true;
            _start = false;
            Console.WriteLine("Объявлен неизвестный грузовик, класса Truck, начальные координаты ({0}, {1})", 0, 0);
        }

        private string _Name;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        private string _NameLoad;

        public string NameLoad
        {
            get
            {
                return _NameLoad;
            }
            set
            {
                _NameLoad = value;
            }
        }

        private bool _frontRigthDoor;

        private bool _frontLeftDoor;

        private bool _backRigthDoor;

        private bool _backLeftDoor;

        private bool _start;

        private int _x;

        private int _y;

        public void SetLoad(string NameLoad)
        {
            _NameLoad = NameLoad;
            Console.WriteLine("Грузовику {0} назначен груз {1}",_Name,_NameLoad);
            return;
            throw new NotImplementedException();
        }

        public void LoadTheTruck()
        {
            Console.WriteLine("Грузовик {0} загружен {1}", _Name,_NameLoad);
            return;
            throw new NotImplementedException();
        }

        public void UnloadTheTrack()
        {
            Console.WriteLine("Грузовик {0} разгружен {1}", _Name, _NameLoad);
            return;
            throw new NotImplementedException();
        }

        public void OpenFrontRigthDoor()
        {
            _frontRigthDoor = false;
            Console.WriteLine("Передняя правая дверь грузовика {0} открыта", _Name);
            return;
            throw new NotImplementedException();
        }

        public void OpenFrontLeftDoor()
        {
            _frontLeftDoor = false;
            Console.WriteLine("Передняя левая дверь грузовика {0} открыта", _Name);
            return;
            throw new NotImplementedException();
        }

        public void OpenBackRigthDoor()
        {
            _backRigthDoor = false;
            Console.WriteLine("Задняя правая дверь грузовика {0} открыта", _Name);
            return;
            throw new NotImplementedException();
        }

        public void OpenBackLeftDoor()
        {
            _backLeftDoor = false;
            Console.WriteLine("Задняя левая дверь грузовика {0} открыта", _Name);
            return;
            throw new NotImplementedException();
        }

        public void CloseFrontRigthDoor()
        {
            _frontRigthDoor = true;;
            Console.WriteLine("Передняя правая дверь грузовика {0} закрыта", _Name);
            return;
            throw new NotImplementedException();
        }

        public void CloseFrontLeftDoor()
        {
            _frontLeftDoor = true;
            Console.WriteLine("Передняя левая дверь грузовика {0} закрыта", _Name);
            return;
            throw new NotImplementedException();
        }

        public void CloseBackRigthDoor()
        {
            _backRigthDoor = true;
            Console.WriteLine("Задняя правая дверь грузовика {0} закрыта", _Name);
            return;
            throw new NotImplementedException();
        }

        public void CloseBackLeftDoor()
        {
            _backLeftDoor = true;
            Console.WriteLine("Задняя левая дверь грузовика {0} закрыта", _Name);
            return;
            throw new NotImplementedException();
        }

        public void StartTheAuto()
        {
            _start = true;
            Console.WriteLine("Грузовик {0} заведен", _Name);
            return;
            throw new NotImplementedException();
        }

        public void TurnOfTheAuto()
        {
            _start = false;
            Console.WriteLine("Грузовик {0} заглушен", _Name);
            return;
            throw new NotImplementedException();
        }

        public void MoveUpTo(int delt)
        {
            _y += delt;
            Console.WriteLine("Координаты грузовика {0} смещены вверх на {1}, текущие координаты ({2}, {3})", _Name, delt,_x,_y);
            return;
            throw new NotImplementedException();
        }

        public void MoveDownTo(int delt)
        {
            _y -= delt;
            Console.WriteLine("Координаты грузовика {0} смещены вниз на {1}, текущие координаты ({2}, {3})", _Name, delt, _x, _y);
            return;
            throw new NotImplementedException();
        }

        public void MoveLeftTo(int delt)
        {
            _x -= delt;
            Console.WriteLine("Координаты грузовика {0} смещены влево на {1}, текущие координаты ({2}, {3})", _Name, delt, _x, _y);
            return;
            throw new NotImplementedException();
        }

        public void MoveRightTo(int delt)
        {
            _x += delt;
            Console.WriteLine("Координаты грузовика {0} смещены вправо на {1}, текущие координаты ({2}, {3})", _Name, delt, _x, _y);
            return;
            throw new NotImplementedException();
        }
    }
}
