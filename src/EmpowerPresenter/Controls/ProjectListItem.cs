/* ePresenter is licensed under the GPLV3 -- see the 'COPYING' file details.
   Copyright (C) 2006 Alex Korchemniy */
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpowerPresenter
{
    public class ProjectListItem
    {
        public IProject project;
        public override string ToString()
        {
            return project.GetName();
        }
    }
}
