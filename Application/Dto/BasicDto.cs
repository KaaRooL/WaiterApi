/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
namespace Application.Dto
{
    public class BasicDto
    {
        public BasicDto()
        {
        }

        public BasicDto(string result)
        {
            Result = result;
        }
        public string Result { get; set; }
    }
}
