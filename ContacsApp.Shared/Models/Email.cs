using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Shared.Models;
public class Email {
    public int Id { get; set; }
    public string EmailAddress { get; set; }
    public EmailType EmailType { get; set; }
    public int ContactId { get; set; }
}

public enum EmailType {
    Home,
    Work,
    Other
}