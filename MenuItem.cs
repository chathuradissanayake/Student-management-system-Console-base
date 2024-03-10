using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKD3910
{
    public class MenuItem
    {
        public string Title { get; set; }
        public bool IsSelected { get; set; }

        //constructor
        public MenuItem(string title, bool isSelected)
        {
            Title = title;
            IsSelected =isSelected;
        }
    }
}
