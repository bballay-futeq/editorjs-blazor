export interface EditorPlugin {
    class: any,
    pluginName: string;
    inlineToolbar: boolean;
    config: any;
}