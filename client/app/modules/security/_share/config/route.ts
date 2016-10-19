let route = {
    permission: {
        permissions: { name: "Permissions", path: "/permissions" },
        addPermission: { name: "Add Permission", path: "/addPermission" },
        editPermission: { name: "Edit Permission", path: "/editPermission/:id" }
    },
    role: {
        roles: { name: "Roles", path: "/roles" },
        addRole: { name: "Add Role", path: "/addRole" },
        editRole: { name: "Edit Role", path: "/editRole/:id" }
    },
    userGroup: {
        userGroups: { name: "UserGroups", path: "/userGroups" },
        addUserGroup: { name: "Add UserGroup", path: "/addUserGroup" },
        editUserGroup: { name: "Edit UserGroup", path: "/editUserGroup/:id" }
    }
};
export default route;