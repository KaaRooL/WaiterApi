using Application.Dto;
using Common.Dispatcher.CommandProcessor;

namespace Application.Commands;

public record UpdateItemsCommand(Guid OrderId, ItemDto[] items) : ICommand;