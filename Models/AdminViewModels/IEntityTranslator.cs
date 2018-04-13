using System;

namespace LucySkyAdmin.Models.AdminViewModels
{
    public interface IEntityTranslator
    {
        string Translate(string input);
    }
}
