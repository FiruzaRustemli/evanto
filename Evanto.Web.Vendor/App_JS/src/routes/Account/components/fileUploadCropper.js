import React, { Component } from 'react'
import ReactDom from 'react-dom'

import FileInput from 'react-md/lib/FileInputs'

class FileUpload extends Component {
    handleFile = (e) => {
        let reader = new FileReader()
        let file = e

        if (!file) return;

        reader.onload = (img) => {
            ReactDom.findDOMNode(this.refs.in).value = ''
            this.props.handleFileChange({ result: img.target.result, name: file.name })
        }
        reader.readAsDataURL(file)
    }

    render() {
        return (
            <FileInput
                id={this.props.id}
                onChange={this.handleFile}
                accept="image/*"
                name="images-2"
                ref='in'
                className={this.props.className}
                floating secondary />
            // <input id={this.props.id} ref='in' type='file' accept='image/*' onChange={this.handleFile} />
        )
    }
}

export default FileUpload