import { EditorPlugin } from "./editor-plugin";

export interface EditorConfig {
    plugins: EditorPlugin[];
    content: any;
    editorID: string;
    autoFocus: boolean;
    logLevel: string;
    placeHolder: string;
}