using BookingTelegramBot.BLL.Interfaces;
using BookingTelegramBot.BLL.Services.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingTelegramBot.BLL.Infrastructure
{
    public class CommandsList
    {
        private static List<ICommand> _commandsList = new List<ICommand>();

        private readonly AuthCommand _authCommand;
        private readonly FreeCommand _freeCommand;
        private readonly CreateRoomCommand _createRoomCommand;
        private readonly UpdateRoomCommand _updateRoomCommand;
        private readonly GetAllRoomsCommand _getAllRoomsCommand;
        private readonly DeleteRoomCommand _deleteRoomCommand;
        private readonly GetAllUsersCommand _getAllUsersCommand;
        private readonly SetRoleCommand _setRoleCommand;
        private readonly CreateParameterCommand _createParameterCommand;
        private readonly UpdateParameterCommand _updateParameterCommand;
        private readonly GetAllParametersCommand _getAllParametersCommand;
        private readonly DeleteParameterCommand _deleteParameterCommand;
        private readonly AllRoomsParametersCommand _allRoomsParametersCommand;

        public CommandsList(AuthCommand authCommand, FreeCommand freeCommand, CreateRoomCommand createRoomCommand,
            UpdateRoomCommand updateRoomCommand, GetAllRoomsCommand getAllRoomsCommand, DeleteRoomCommand deleteRoomCommand, GetAllUsersCommand getAllUsersCommand,
            SetRoleCommand setRoleCommand, CreateParameterCommand createParameterCommand, UpdateParameterCommand updateParameterCommand,
            GetAllParametersCommand getAllParametersCommand, DeleteParameterCommand deleteParameterCommand, AllRoomsParametersCommand allRoomsParametersCommand)
        {
            _authCommand = authCommand;
            _freeCommand = freeCommand;
            _createRoomCommand = createRoomCommand;
            _updateRoomCommand = updateRoomCommand;
            _getAllRoomsCommand = getAllRoomsCommand;
            _deleteRoomCommand = deleteRoomCommand;
            _getAllUsersCommand = getAllUsersCommand;
            _setRoleCommand = setRoleCommand;
            _createParameterCommand = createParameterCommand;
            _updateParameterCommand = updateParameterCommand;
            _getAllParametersCommand = getAllParametersCommand;
            _deleteParameterCommand = deleteParameterCommand;
            _allRoomsParametersCommand = allRoomsParametersCommand;
            Initialize();
        }        

        public List<ICommand> Commands 
        { 
            get 
            {
                return _commandsList;
            }
            set { } 
        }

        public void Initialize()
        {
            _commandsList.Add(new StartCommand());
            _commandsList.Add(_authCommand);
            _commandsList.Add(_freeCommand);
            _commandsList.Add(_createRoomCommand);
            _commandsList.Add(_updateRoomCommand);
            _commandsList.Add(_getAllRoomsCommand);
            _commandsList.Add(_deleteRoomCommand);
            _commandsList.Add(_getAllUsersCommand);
            _commandsList.Add(_setRoleCommand);
            _commandsList.Add(_createParameterCommand);
            _commandsList.Add(_updateParameterCommand);
            _commandsList.Add(_getAllParametersCommand);
            _commandsList.Add(_deleteParameterCommand);
            _commandsList.Add(_allRoomsParametersCommand);
        }
    }
}
