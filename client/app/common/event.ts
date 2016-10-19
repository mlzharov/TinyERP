export const ComponentType = {
    Layout: "layout",
    Page: "page",
    Control: "control"
};
export const AuthenticatedEvent = {
    AuthenticationChanged: "AuthenticationChanged"
};
export const CommonEvent = {
    ValidationFail: "ValidationFail"
};
export const LoadingIndicatorEvent = {
    Show: "show",
    Hide: "hide"
};

export const HttpCode = {
    NotFound: 404,
    UnAuthorized: 401,
    BadRequest: 400
};

export const ValidationEvent = {
    ValidationFail: "ValidationFail"
};
export const ApplicationStateEvent = {
    Init: "ApplicationStateEvent.Init",
    BeforeReady: "ApplicationStateEvent.BeforeReady",
    Ready: "ApplicationStateEvent.Ready",
    Unload: "ApplicationStateEvent.Unload",
    UnAuthorizeRequest: "UnAuthorizeRequest"
};