using System;

namespace UnfrozenTestProject
{
    public interface IModel
    {
        event Action<string, object> PropertyChanged;
    }
}
