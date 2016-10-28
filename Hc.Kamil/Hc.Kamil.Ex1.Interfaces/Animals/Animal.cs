﻿namespace Hc.Kamil.Ex1.Interfaces.Animals
{
    public abstract class Animal
    {
        private readonly string _name;

        protected Animal(string name)
        {
            _name = name;
        }

        protected string GetGreeting()
        {
            return $"Hello, my name is {_name}";
        }
    }
}