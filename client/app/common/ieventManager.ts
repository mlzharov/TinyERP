export interface IEventManager {
    subscribe(eventType: string, eventHandler: any): void;
    unsubscribe(eventType: string): void;
    publish(eventType: string, eventArgs: any): void;
}