using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LAB1_MEGAN_MORALES_1221120.Helpers;
using Microsoft.AspNetCore.Http;

namespace LAB1_MEGAN_MORALES_1221120.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(1)]
        public string Name { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(1)]
        public string LastName { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "Enter a correct number", MinimumLength = 8)]
        public int Phone { get; set; }
        [MaxLength(100)]
        [MinLength(0)]
        public string Description { get; set; }

        public static bool Save(ClientModel model)
        {
            Singelton.Instance.ClientList.Add(model);
            return true;
        }

        public static bool Edit(int id, ClientModel model)
        {
            var position = Singelton.Instance.ClientList.FindIndex(client => client.Id == id);
            Singelton.Instance.ClientList[position] = new ClientModel
            {
                Id = id,
                Name = model.Name,
                LastName = model.LastName,
                Phone = model.Phone,
                Description = model.Description,
            };

            return true;
        }
    }
}
