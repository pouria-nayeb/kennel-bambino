using kennel_bambino.web.Models;
using kennel_bambino.web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Interfaces
{
    public interface IMessageService
    {
        Contact AddContact(Contact contact);
        Task<Contact> AddContactAsync(Contact contact);

        ContactPagingViewModel GetContacts(int pageNumber, int pageSize);
        Task<ContactPagingViewModel> GetContactsAsync(int pageNumber, int pageSize);

        Contact GetContactById(int contactId);
        Task<Contact> GetContactByIdAsync(int contactId);

        Contact UpdateContact(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);

        void RemoveMessage(int contactId);
        Task RemoveMessageAsync(int contactId);

        List<Contact> SearchContacts(string phoneNumber);
        Task<List<Contact>> SearchContactsAsync(string phoneNumber);
    }
}
