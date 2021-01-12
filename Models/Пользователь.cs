using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Vkontakte.Models
{
    public class Пользователь
    {
        public Пользователь()
        {
            Дружбы = new List<Дружба>();
            ИменияДружб = new List<Дружба>();
            Участия = new List<Участник>();
            Коментарии = new List<Коментарий>();
            Блоги = new List<Блог>();
            Подписки = new List<Подписчик>();
            Действия = new List<Дествие>();
            Аватарки = new List<Аватарка>();
        }
        [Key]
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполненым")]
        public string Фамилия { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполненым")]
        public string Имя { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполненым")]
        public DateTime Дата_рождения { get; set; }
        public string Город { get; set; }
        public string Страна { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполненым")]
        public string Никнейм { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполненым")]
        public string Пароль { get; set; }
        public string _token { get; set; }
        public string _salt { get; set; }
        public IEnumerable<Дружба> Дружбы { get; set; }
        public IEnumerable<Дружба> ИменияДружб { get; set; }
        public IEnumerable<Участник> Участия { get; set; }
        public IEnumerable<Коментарий> Коментарии { get; set; }
        public IEnumerable<Блог> Блоги { get; set; }
        public IEnumerable<Подписчик> Подписки { get; set; }
        public IEnumerable<Дествие> Действия { get; set; }
        public IEnumerable<Аватарка> Аватарки { get; set; }
    }
}
