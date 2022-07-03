using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
