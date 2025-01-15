using Microsoft.AspNetCore.Mvc;
using VirtualPetAdoption.APIs.Common;
using VirtualPetAdoption.Infrastructure.Models;

namespace VirtualPetAdoption.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class NewsFindManyArgs : FindManyInput<News, NewsWhereInput> { }
