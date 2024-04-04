﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneCompany.Model.Entities;

namespace PhoneCompany.Services;

public interface IConversationService
{
    Task<IEnumerable<Conversation>> GetDataAsync();
}