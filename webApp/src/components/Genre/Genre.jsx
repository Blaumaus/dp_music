import React from "react";
import useStyles from "../EntityPageComponents.styles"
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import { Formik, Form, ErrorMessage } from 'formik';
import * as yup from 'yup';
import TextField from '@material-ui/core/TextField';
import CssBaseline from '@material-ui/core/CssBaseline';
import Avatar from '@material-ui/core/Avatar';
import IconButton from '@material-ui/core/IconButton';
import PhotoCamera from '@material-ui/icons/PhotoCamera';
import styles from './Genres.module.css';
import GenreCard from 'components/EntityCard/EntityCard';
import MainAdminMenu from 'components/MainAdminMenu/MainAdminMenu'
import { Link } from 'react-router-dom';
import Breadcrumbs from '@material-ui/core/Breadcrumbs';
import ArrowForwardIosIcon from '@material-ui/icons/ArrowForwardIos';

const Genre = props => {

    const classes = useStyles()

    const { handleUpload, onChange, handleClickCreate,
        handleClickEdit, handleClickDelete, handleSubmit,
        genres, ImagefileToView, disableField, selectedGenre,
        handleButtonBackClick, handleGenreItemClick, user, buttonsback } = props

    const validationSchema = yup.object({
        name: yup.string()
            .required("Введіть Назву"),
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
                        return <Button key={button.name} component={Link} to={button.link}>
                            {button.name}
                        </Button>
                    })}
                </Breadcrumbs>
            </div>
            {user.role === 'Admin' ? (<div>{selectedGenre ?
                (<div className={classes.paperForm}>

                    <Formik className={classes.form}
                        initialValues={{ ...selectedGenre }}
                        validationSchema={validationSchema}
                        onSubmit={handleSubmit}
                        enableReinitialize={true}
                    >
                        {({ handleSubmit, values, touched, errors }) => (
                            <Form onSubmit={handleSubmit}>

                                <div className={classes.upload}>
                                    <img src={ImagefileToView} className={classes.avatar} />
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
                                            label="Name"
                                            disabled={disableField}
                                            fullWidth
                                            error={touched.name && Boolean(errors.name)}
                                            helperText={touched.name && errors.name}

                                        />
                                    </Grid>
                                    <Grid item xs={12}>
                                        <TextField
                                            onChange={onFieldChange}
                                            name="description"
                                            value={values.description}
                                            placeholder="Опис"
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
                        items={genres}
                        onClickCreate={handleClickCreate}
                        onClickEdit={handleClickEdit}
                        onClickDelete={handleClickDelete}
                        onClickItem={handleGenreItemClick}
                    />
                )
            }
            </div>) : (
                <div className={styles.mediaContainer}>
                    {genres.map(genre => {
                        return <GenreCard
                            key={genre.id}
                            name={genre.name}
                            image={genre.image}
                            description={genre.description}
                            onClick={() => handleGenreItemClick(genre)}
                            id={genre.id}
                        >
                        </GenreCard>
                    })}

                </div>)}
        </div >
    );
}
export default Genre;