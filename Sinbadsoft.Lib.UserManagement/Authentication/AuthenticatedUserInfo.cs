// <copyright file="AuthenticatedUserInfo.cs" company="Sinbadsoft">
// Copyright (c) Chaker Nakhli 2010-2013
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at http://www.apache.org/licenses/LICENSE-2.0 Unless required by 
// applicable law or agreed to in writing, software distributed under the License
// is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing
// permissions and limitations under the License.
// </copyright>
// <author>Chaker Nakhli</author>
// <email>chaker.nakhli@sinbadsoft.com</email>
// <date>2012/07/28</date>
namespace Sinbadsoft.Lib.UserManagement.Authentication
{
    public class AuthenticatedUserInfo
    {
        public AuthenticatedUserInfo()
        {
            this.Data = "";
        }

        public AuthenticatedUserInfo(int id, string email, string data = "")
        {
            this.Email = email;
            this.Id = id;
            this.Data = data;
        }

        public string Email { get; private set; }

        public int Id { get; private set; }

        public string Data { get; private set; }
    }
}