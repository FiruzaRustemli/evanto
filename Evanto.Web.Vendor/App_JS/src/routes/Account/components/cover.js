import React, { Component } from 'react'
import CropperModal from './cropperModal'
import FileUpload from './fileUploadCropper'
import { fileExtension } from '../../../config'
import AvatarCropper from 'react-avatar-cropper'
import '../styles/account.scss'
import { urlConfig } from '../../../config'
import { changeFontSize } from '../../../helpers'

import Button from 'react-md/lib/Buttons/Button'

class Cover extends Component {
	constructor(props) {
		super(props)
		this.state = {
			imgSelected: '',
			showCropper: false,
			fileExt: '',
			mediaType: '',
			data: ''
		}
	}

	showCropper = (args) => {
		this.setState({
			img: args,
			showCropper: true
		})
	}
	hide = () => {
		this.setState({
			showCropper: false
		})
	}
	crop = (args) => {
		const { uploadAvatar, vendor } = this.props
		let model = {
			mediaType: this.state.mediaType,
			container: args.split(/,(.+)/)[1],
			extension: this.state.fileExt.replace('.', '')
		}
		this.setState({
			showCropper: false
		})
		uploadAvatar(model)
	}
	handleFileChange = ({ result, name }) => {
		let fileExt = fileExtension.exec(name)[1]
		let mediaType = result.split(/,(.+)/)[0].split(/;(.+)/)[0].split(/:(.+)/)[1]
		let data = result.split(/,(.+)/)[1]
		this.setState({
			imgSelected: result,
			showCropper: true,
			fileExt: fileExtension.exec(name)[0],
			mediaType: result.split(/,(.+)/)[0].split(/;(.+)/)[0].split(/:(.+)/)[1],
		})
	}
	render() {
		const { vendor, width } = this.props
		return (
			<div className='md-grid cover-user' style={{ backgroundImage: `url(${urlConfig.getCurrentProjectAddress()}assets/img/mmmk.png)` }}>
				<div className='md-cell md-cell--3-desktop md-cell--12-tablet md-cell--12-phone '>
					<div className='image-container'>
						<img className='img-profile img-circle img-responsive auto-width'
							src={`${(vendor && vendor.file && vendor.file.container)
								? `data:${vendor.file.mediaType};base64, ${vendor.file.container}`
								: `${urlConfig.getCurrentProjectAddress()}/assets/img/download.png`}`}
							alt=''
						/>
						<FileUpload className='file-upload-profile' id='file-input' handleFileChange={this.handleFileChange} />
					</div>

				</div>
				<div className="md-cell md-cell--9-desktop md-cell--12-tablet md-cell--12-phone">
					<div className={`middle-text-div-parent ${width < 1030 ? 'center-div' : ''}`}>
						<div className='middle-text-div'>
							<h3 className='label-name' style={{ fontSize: `${changeFontSize(width, (vendor.user.firstName + vendor.user.lastName).length)}` }}>
								{`${vendor.user.firstName} ${vendor.user.lastName}`}
							</h3>
							<small className='label-description'>{vendor.name}</small>
						</div>
					</div>
				</div>
				<AvatarCropper
					onRequestHide={this.hide}
					cropperOpen={this.state.showCropper}
					onCrop={this.crop}
					image={this.state.imgSelected}
					width={300}
					height={300}
				/>
			</div >
		)
	}
}

export default Cover