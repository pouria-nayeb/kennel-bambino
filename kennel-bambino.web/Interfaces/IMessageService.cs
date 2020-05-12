using kennel_bambino.web.Models;
using kennel_bambino.web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kennel_bambino.web.Interfaces
{
    public interface IMessageService : IDisposable
    {
        #region Add new contact
        Contact AddContact(Contact contact);
        Task<Contact> AddContactAsync(Contact contact);
        #endregion

        #region Get contacts
        ContactPagingViewModel GetContacts(int pageNumber, int pageSize);
        Task<ContactPagingViewModel> GetContactsAsync(int pageNumber, int pageSize);
        #endregion

        #region Get contact by id
        Contact GetContactById(int contactId);
        Task<Contact> GetContactByIdAsync(int contactId);
        #endregion

        #region update contact
        Contact UpdateContact(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        #endregion

        #region Remove contact
        void RemoveContact(int contactId);
        Task RemoveContactAsync(int contactId);
        #endregion

        #region Search contacts
        List<Contact> SearchContacts(string phoneNumber);
        Task<List<Contact>> SearchContactsAsync(string phoneNumber);
        #endregion

        #region Contacts count
        int ContactsCount();
        Task<int> ContactsCountAsync();
        #endregion

        #region New contacts count
        int NewContactsCount();
        Task<int> NewContactsCountAsync();
        #endregion
    }
}
