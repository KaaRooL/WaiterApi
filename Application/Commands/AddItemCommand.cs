using Application.Dto;
using Common.Dispatcher.CommandProcessor;

namespace Application.Commands;

public record AddItemCommand(Guid OrderId, ItemDto Item): ICommand;