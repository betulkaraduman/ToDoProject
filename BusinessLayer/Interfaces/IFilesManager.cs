using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IFilesManager
    {
        string givePDF<T>(List<T> list) where T : class, new();
        byte[] giveExcel<T>(List<T> list) where T : class, new();
        string AktarPdf<T>(List<T> list) where T : class, new();
        /// <summary>
        /// Geriye excel verisini byte dizisi olarak döner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        byte[] AktarExcel<T>(List<T> list) where T : class, new();
    }
}
