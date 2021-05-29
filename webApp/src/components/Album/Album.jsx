import React, { useState } from "react";
import useStyles from "../EntityPageComponents.styles"
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import { Formik, Form, ErrorMessage } from 'formik'
import * as yup from 'yup';
import TextField from '@material-ui/core/TextField';
import CssBaseline from '@material-ui/core/CssBaseline';
import Avatar from '@material-ui/core/Avatar';
import IconButton from '@material-ui/core/IconButton';
import PhotoCamera from '@material-ui/icons/PhotoCamera';
import styles from './Albums.module.css';
import AlbumCard from 'components/EntityCard/EntityCard';
import MainAdminMenu from 'components/MainAdminMenu/MainAdminMenu'
import { Link } from 'react-router-dom';
import Breadcrumbs from '@material-ui/core/Breadcrumbs';
import ArrowForwardIosIcon from '@material-ui/icons/ArrowForwardIos';


const Album = props => {

    const classes = useStyles()

    const { handleUpload, onChange, handleClickCreate,
        handleClickEdit, handleClickDelete, handleSubmit,
        albums, file, disableField, isAdmin, selectedAlbum,
        handleButtonBackClick, handleAlbumItemClick, buttonsback } = props
    const today = new Date(Date.now());
    const validationSchema = yup.object({
        name: yup.string()
            .required("Введіть Назву"),
        year: yup.number()
            .min(1970).max(today.getFullYear()),
        description: yup.string(),

    });

    const onFieldChange = (event) => {
        const fieldName = event.target.name;
        const fieldValue = event.target.value;
        onChange(fieldName, fieldValue);
    };

    return (
        <div>
            <CssBaseline />
            <div className={classes.buttonsBackContainer}>
                <Breadcrumbs separator={<ArrowForwardIosIcon fontSize="small" />}>
                    {buttonsback.map(button => {
                        return <Button component={Link} to={button.link}>
                            {button.name}
                        </Button>
                    })}
                </Breadcrumbs>
            </div>
            {isAdmin ? (<div>{selectedAlbum ?
                (<div className={classes.paperForm}>

                    <Formik className={classes.form}
                        initialValues={{ ...selectedAlbum }}
                        validationSchema={validationSchema}
                        onSubmit={handleSubmit}
                        enableReinitialize={true}
                    >
                        {({ handleSubmit, values, touched, errors }) => (
                            <Form onSubmit={handleSubmit}>

                                <div className={classes.upload}>
                                    <img src={file} className={classes.avatar} />
                                    <input
                                        accept="image/*"
                                        className={classes.input}
                                        id="icon-button-file"
                                        multiple
                                        type="file"
                                        name="avatar"
                                        onChange={handleUpload}
                                        disabled={disableField}

                                    />
                                    <label htmlFor="icon-button-file">
                                        <IconButton color="primary" aria-label="upload picture" component="span">
                                            <PhotoCamera />
                                        </IconButton>
                                    </label>

                                </div>
                                <Grid container spacing={2}>
                                    <Grid item xs={12}>
                                        <TextField
                                            onChange={onFieldChange}
                                            name="name"
                                            variant="outlined"
                                            value={values.name}
                                            label="Назва"
                                            disabled={disableField}
                                            fullWidth
                                            error={touched.name && Boolean(errors.name)}
                                            helperText={touched.name && errors.name}

                                        />
                                    </Grid>
                                    <Grid item xs={12}>
                                        <TextField
                                            onChange={onFieldChange}
                                            name="year"
                                            variant="outlined"
                                            value={values.year}
                                            label="Рік випуску"
                                            disabled={disableField}
                                            fullWidth
                                            error={touched.year && Boolean(errors.year)}
                                            helperText={touched.year && errors.year}

                                        />
                                    </Grid>
                                    <Grid item xs={12}>
                                        <TextField
                                            onChange={onFieldChange}
                                            name="description"
                                            value={values.description}
                                            placeholder="Description"
                                            variant="outlined"
                                            multiline
                                            disabled={disableField}
                                            fullWidth
                                            rows={3}
                                            rowsMax={10}
                                            error={touched.description && Boolean(errors.description)}
                                            helperText={touched.description && errors.description}
                                        />
                                    </Grid>
                                </Grid>

                                <div className={classes.buttonsFormContainer}>
                                    <div className={classes.buttonSubmitContainer}>
                                        <Button
                                            type="submit"
                                            fullWidth
                                            variant="contained"
                                            color="primary"
                                            className={classes.submit}
                                        >
                                            Підтвердити
                                </Button>
                                    </div>
                                    <div className={classes.buttonBackContainer}>
                                        <Button variant="contained" fullWidth className={classes.buttonBack} onClick={handleButtonBackClick}>
                                            Назад
                                </Button>
                                    </div>
                                </div>
                            </Form>

                        )}
                    </Formik>
                </div>)
                : (
                    <MainAdminMenu
                        items={albums}
                        onClickCreate={handleClickCreate}
                        onClickEdit={handleClickEdit}
                        onClickDelete={handleClickDelete}
                        onClickItem={handleAlbumItemClick}
                    />
                )
            }
            </div>) : (
                <div className={styles.mediaContainer}>
                    {albums.map(album => {
                        return <AlbumCard
                            key={album.id}
                            name={album.name}
                            image={album.image}
                            description={album.description}
                            onClick={() => handleAlbumItemClick(album)}
                            id={album.id}
                        >
                        </AlbumCard>
                    })}

                </div>)}

        </div >
    );
}
export default Album;