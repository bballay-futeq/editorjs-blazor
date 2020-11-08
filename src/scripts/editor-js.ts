import EditorJS, { LogLevels } from "@editorjs/editorjs";
import { EditorInteropComponent } from "./editor-interop-component";
import { EditorConfig } from "./editor-config";
import { EditorPlugin } from "./editor-plugin";

import Paragraph from "@editorjs/paragraph";
import Header from "@editorjs/header";
import List from "@editorjs/list";
import Link from "@editorjs/link";
import Code from "@editorjs/code";
import Checklist from "@editorjs/checklist";
import Marker from "@editorjs/marker";
import Quote from "@editorjs/quote";
import SimpleImage from "@editorjs/simple-image";
import Warning from "@editorjs/warning";


export class EditorJsWrapper extends EditorInteropComponent {
    private editorJsInstance: EditorJS;
    private classMap: { [key: string]: any } = {};

    constructor(public componentId: string, public domElement: HTMLElement, public blazorInstance: any) {        
        super(componentId, domElement, blazorInstance); 
    }

    async initialize(elementId: string) {
        const editorConfig = await this.getBlazorProperty("Config");

        if (editorConfig != null) {
            const data = editorConfig.content != null ? JSON.parse(editorConfig.content) : null

            console.log(data);

            this.setupClassMap();
            this.editorJsInstance = new EditorJS({
                holder: elementId,
                tools: this.getTools(editorConfig),
                onChange: async () => {
                    await this.getData();
                }, 
                autofocus: editorConfig.autoFocus,
                placeholder: editorConfig.placeholder,
                data: data
            }); 
        }
    }

    async getData() {
        const data = await this.editorJsInstance.save();
        await this.blazorInstance.invokeMethodAsync("SetValue", JSON.stringify(data));
    }

    public getTools(config: EditorConfig): any {
        let tools: any = {};

        config.plugins.forEach(plugin => {
            this.setTool(tools, plugin);
        }); 

        return tools;
    }

    private setupClassMap() {
        this.classMap['paragraph'] = Paragraph;
        this.classMap['header'] = Header;
        this.classMap['list'] = List;
        this.classMap['link'] = Link;
        this.classMap['code'] = Code;
        this.classMap['checklist'] = Checklist;
        this.classMap['marker'] = Marker;
        this.classMap['quote'] = Quote;
        this.classMap['image'] = SimpleImage;
        this.classMap['warning'] = Warning;
    }

    private setTool(tools: any, plugin: EditorPlugin) {
        const pluginClass = this.classMap[plugin.pluginName];

        if (pluginClass) {
            tools[plugin.pluginName] = {
                class: pluginClass,
                inlineToolbar: plugin.inlineToolbar
            };
        }
    }

    async destroy() {
        this.editorJsInstance.destroy();
    }
}

export class EditorJsHandler {
    editors: { [key: string]: EditorJsWrapper } = {};

    constructor() {}

    async initializeEditor(editorId: string, domElement: HTMLElement, blazorInstance: any) {
        if (this.editors[editorId]) {
            await this.editors[editorId].destroy();
        }

        const editor = new EditorJsWrapper(editorId, domElement, blazorInstance);

        await editor.initialize(editorId);

        this.editors[editorId] = editor;
    }

    callEditorMethod(componentId: string, methodName: string, ...params: any[]): void {
        return this.editors[componentId][methodName](...params);
    }
}

declare global {
    interface Window {
        editorJsHandler: EditorJsHandler;
    }
}

window.editorJsHandler = new EditorJsHandler();