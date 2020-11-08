export abstract class EditorInteropComponent {
    constructor(public componentId: string, public domElement: HTMLElement, public blazorInstance: any) { }

    abstract initialize(elementId: string): void;

    async getBlazorProperty(propertyName: string) {
        return await this.blazorInstance.invokeMethodAsync("GetBlazorProperty", propertyName);
    }
} 