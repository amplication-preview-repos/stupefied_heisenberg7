using Microsoft.AspNetCore.Mvc;
using VirtualPetAdoption.APIs.Common;
using VirtualPetAdoption.Infrastructure.Models;

namespace VirtualPetAdoption.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class SubscriptionFindManyArgs : FindManyInput<Subscription, SubscriptionWhereInput> { }
