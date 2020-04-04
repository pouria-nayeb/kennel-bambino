using kennel_bambino.web.Data;
using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using kennel_bambino.web.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kennel_bambino.web.Services
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MessageService> _logger;

        public MessageService(ApplicationDbContext context, ILogger<MessageService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Contact AddContact(Contact contact)
        {
            try
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();

                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public async Task<Contact> AddContactAsync(Contact contact)
        {
            try
            {
                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();

                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public ContactPagingViewModel GetContacts(int pageNumber = 1, int pageSize = 30)
        {
            IQueryable<Contact> contacts = _context.Contacts;

            int take = pageSize;
            int skip = (pageNumber - 1) * take;
            int contactsCount = contacts.Count();

            int pageCount = (int)Math.Ceiling(Decimal.Divide(contactsCount, take));

            return new ContactPagingViewModel
            {
                Contacts = contacts.Skip(skip).Take(take)
                .OrderByDescending(c => c.ContactId)
                .ToList(),
                PageNumber = pageNumber,
                PageCount = pageCount
            };
        }

        public async Task<ContactPagingViewModel> GetContactsAsync(int pageNumber = 1, int pageSize = 30) 
        {
            IQueryable<Contact> contacts = _context.Contacts;

            int take = pageSize;
            int skip = (pageNumber - 1) * take;
            int contactsCount = contacts.Count();

            int pageCount = (int)Math.Ceiling(Decimal.Divide(contactsCount, take));

            return new ContactPagingViewModel
            {
                Contacts = await contacts.Skip(skip).Take(take)
                .OrderByDescending(c => c.ContactId)
                .ToListAsync(),
                PageNumber = pageNumber,
                PageCount = pageCount
            };
        }

        public Contact GetContactById(int contactId) => _context.Contacts.Find(contactId);

        public async Task<Contact> GetContactByIdAsync(int contactId) => await _context.Contacts
            .FindAsync(contactId);

        public Contact UpdateContact(Contact contact) 
        {
            try
            {
                 _context.Contacts.Update(contact);
                 _context.SaveChanges();

                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            try
            {
                _context.Contacts.Update(contact);
                await _context.SaveChangesAsync();

                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public void RemoveMessage(int contactId)
        {
            var contact = GetContactById(contactId);

            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public async Task RemoveMessageAsync(int contactId)
        {
            var contact = await GetContactByIdAsync(contactId);

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        public List<Contact> SearchContacts(string phoneNumber) => _context.Contacts
            .Where(c => c.PhoneNumber.Contains(phoneNumber))
            .ToList();

        public async Task<List<Contact>> SearchContactsAsync(string phoneNumber) => await _context.Contacts
            .Where(c => c.PhoneNumber.Contains(phoneNumber))
            .ToListAsync();
    }
}
