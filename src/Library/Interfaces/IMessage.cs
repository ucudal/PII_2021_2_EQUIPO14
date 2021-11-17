using System;

namespace Proyecto_Final
{
    public interface IMessage
    {
        string UserId {get;}
        string ChatId {get;}
        string Text {get;}
        string FirstName {get;}
        string LastName {get;}
        DateTime Date {get;}
    }
}