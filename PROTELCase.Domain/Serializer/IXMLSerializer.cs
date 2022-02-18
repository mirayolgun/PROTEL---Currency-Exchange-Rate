using System;
using System.Collections.Generic;
using System.Text;

namespace PROTELCase.Domain.Serializer
{
    public interface IXMLSerializer
    {
        T Deserializer<T>(string value);
        string Serializer(object value);

    }
}
