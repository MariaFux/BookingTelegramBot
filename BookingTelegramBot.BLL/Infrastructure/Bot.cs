﻿using BookingTelegramBot.BLL.Interfaces;
using BookingTelegramBot.BLL.Services.Commands;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BookingTelegramBot.BLL.Infrastructure
{
    public class Bot
    {
        private static TelegramBotClient _botClient;
        private static List<ICommand> _commandsList = new List<ICommand>();
        private readonly BotSettings _settings;

        private readonly AuthCommand _authCommand;
        private readonly FreeCommand _freeCommand;
        private readonly CreateCommand _createCommand;
        private readonly UpdateCommand _updateCommand;
        private readonly GetAllRoomsCommand _getAllRoomsCommand;
        private readonly DeleteCommand _deleteCommand;
        private readonly GetAllUsersCommand _getAllUsersCommand;
        private readonly SetRoleCommand _setRoleCommand;

        public Bot(IOptions<BotSettings> settings, AuthCommand authCommand, FreeCommand freeCommand, CreateCommand createCommand, 
            UpdateCommand updateCommand, GetAllRoomsCommand getAllRoomsCommand, DeleteCommand deleteCommand, GetAllUsersCommand getAllUsersCommand,
            SetRoleCommand setRoleCommand)
        {
            _settings = settings.Value;
            _authCommand = authCommand;
            _freeCommand = freeCommand;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _getAllRoomsCommand = getAllRoomsCommand;
            _deleteCommand = deleteCommand;
            _getAllUsersCommand = getAllUsersCommand;
            _setRoleCommand = setRoleCommand;
        }

        public IReadOnlyList<ICommand> Commands => _commandsList.AsReadOnly();

        public async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (_botClient != null)
            {
                return _botClient;
            }

            _botClient = await BotInitialization();            

            return _botClient;
            
        }

        private async Task<TelegramBotClient> BotInitialization()
        {
            _commandsList.Add(new StartCommand());
            _commandsList.Add(_authCommand);
            _commandsList.Add(_freeCommand);
            _commandsList.Add(_createCommand);
            _commandsList.Add(_updateCommand);
            _commandsList.Add(_getAllRoomsCommand);
            _commandsList.Add(_deleteCommand);
            _commandsList.Add(_getAllUsersCommand);
            _commandsList.Add(_setRoleCommand);
            //TODO: Add more commands

            var botClient = new TelegramBotClient(_settings.Token);

            string hook = $"{_settings.BaseUrl}api/message/postmessage";

            await botClient.SetWebhookAsync(hook);

            return botClient;
        }
    }
}
