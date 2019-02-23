﻿using System.Collections.Generic;
using System.Text;

namespace FailToBan.Core
{
    public class Setting : ISetting
    {
        private readonly Dictionary<string, ISection> sections = new Dictionary<string, ISection>();

        /// <summary>
        /// Возвращает секцию из файла конфигурации по названию
        /// </summary>
        /// <param name="name">Название секции</param>
        /// <returns>Секция в файле конфигурации</returns>
        public ISection GetSection(string name)
        {
            return sections.TryGetValue(name, out var section) ? section : null;
        }

        /// <summary>
        /// Добавляет в файл конфигурации новую секцию
        /// </summary>
        /// <param name="name">Название добавляемой секции</param>
        /// <param name="section">Секция</param>
        /// <returns>true если секция была добавлена, false если секция с таким именем уже существует</returns>
        public bool AddSection(string name, ISection section)
        {
            return sections.TryAdd(name, section);
        }

        /// <summary>
        /// Возвращает текстовое представление конфигурационного файла для записи в файл
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var (name, section) in sections)
            {
                builder.Append(section.ToString(name));
            }

            return builder.ToString();
        }
    }
}