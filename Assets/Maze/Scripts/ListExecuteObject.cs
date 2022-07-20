using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Maze
{

    public class ListExecuteObject : IEnumerable, IEnumerator
    {
        private IExecute[] _listInteractiveObjects;

        private const int INDEX_DEFAULT = -1;
        private int _index = INDEX_DEFAULT;

        public object Current => _listInteractiveObjects[_index];
        public int Lenght => _listInteractiveObjects.Length;

        public IExecute this[int current]
        {
            get => _listInteractiveObjects[current];
        }

        public ListExecuteObject()
        {
            Bonus[] bonusObjects = Object.FindObjectsOfType<Bonus>();

            for(int i = 0; i < bonusObjects.Length; i++)
            {
                if(bonusObjects[i] is IExecute intObj)
                {
                    AddExecuteObject(intObj);
                }
            }
        }

        public void AddExecuteObject(IExecute execute)
        {
            if(_listInteractiveObjects == null)
            {
                _listInteractiveObjects = new[] { execute };
            }

            Array.Resize(ref _listInteractiveObjects, Lenght + 1);
            _listInteractiveObjects[Lenght - 1] = execute;
        }

        public bool MoveNext()
        {
            if(_index == Lenght - 1)
            {
                return false;
            }

            _index++;
            return true;
        }

        public void Reset()
        {
            _index = INDEX_DEFAULT;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
