import {EventEmitter} from "angular2/core";
import {Hashtable} from "./models/list/hashtable";
import {IEventManager} from "./ieventManager";
export class EventManager implements IEventManager {
    private eventEmitterMap: Hashtable<EventEmitter<any>> = new Hashtable<EventEmitter<any>>();
    public subscribe(eventType: string, eventHandler: any) {
        if (false === this.eventEmitterMap.exist(eventType)) {
            this.eventEmitterMap.set(eventType, new EventEmitter<any>());
        }
        this.eventEmitterMap.get(eventType).subscribe(eventHandler);
    }
    public unsubscribe(eventType: string) {
        this.eventEmitterMap.remove(eventType);
    }
    public publish(eventType: string, eventArgs: any = null) {
        if (true === this.eventEmitterMap.exist(eventType)) {
            this.eventEmitterMap.get(eventType).emit(eventArgs);
        } else {
            console.log("handler for " + eventType + " was not found");
        }
    }
}