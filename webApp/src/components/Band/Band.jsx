import React, { useState } from "react";
import Typography from '@material-ui/core/Typography';
import useStyles from "../EntityPageComponents.styles"
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import { Formik, Form, ErrorMessage } from 'formik'
import * as yup from 'yup';
import TextField from '@material-ui/core/TextField';
import CssBaseline from '@material-ui/core/CssBaseline';
import Avatar from '@material-ui/core/Avatar';
import IconButton from '@material-ui/core/IconButton';
import PhotoCamera from '@material-ui/icons/PhotoCamera';
import styles from './Bands.module.css';
import BandCard from 'components/EntityCard/EntityCard';
import MainAdminMenu from 'components/MainAdminMenu/MainAdminMenu'
import DateFnsUtils from '@date-io/date-fns';
import {
    MuiPickersUtilsProvider,
    KeyboardDatePicker,
} from '@material-ui/pickers';
import { Link } from 'react-router-dom';
import Breadcrumbs from '@material-ui/core/Breadcrumbs';
import ArrowForwardIosIcon from '@material-ui/icons/ArrowForwardIos';
import Select from '@material-ui/core/Select';
import InputLabel from '@material-ui/core/InputLabel';
import FormControl from '@material-ui/core/FormControl';
import moment from 'moment';

const Band = props => {

    const classes = useStyles()

    const { handleUpload, onChange, handleClickCreate,
        handleClickEdit, handleClickDelete, handleSubmit,
        bands, disableField, selectedBand,
        handleButtonBackClick, handleBandItemClick, buttonsback, genres, ImagefileToView, user } = props

    const today = new Date(Date.now());
    const validationSchema = yup.object({
        name: yup.string()
            .required("Введіть Назву"),
        description: yup.string(),
        countryCode: yup.string().matches(/^[a-zA-Z]*$/, "Не вірний формат").length(2, "Не вірний формат"),
        foundationDate: yup.date(),
        genreId: yup.string().required("Виберіть жанр"),
    });

    const handleFieldChange = (event) => {
        const fieldName = event.target.name;
        const fieldValue = event.target.value;
        onChange(fieldName, fieldValue);
    };
    const handleDateChange = (date) => {
        const fieldName = 'foundationDate';
        const fieldValue = date;
        onChange(fieldName, fieldValue);
    };

    return (
        <div>
            <CssBaseline />
            <div className={classes.buttonsBackContainer}>
                <Breadcrumbs separator={<ArrowForwardIosIcon fontSize="small" />}>
                    {buttonsback.map(button => {
                        return <Button  key={button.name} component={Link} to={button.link}>
                            {button.name}
                        </Button>
                    })}
                </Breadcrumbs>
            </div>
            {user.role === 'Admin' ? (<div>{selectedBand ?
                (<div className={classes.paperForm}>

                    <Formik className={classes.form}
                        initialValues={{ ...selectedBand }}
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
                                    <Grid item xs={12} sm={6}>
                                        <TextField
                                            onChange={handleFieldChange}
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
                                    <Grid item xs={12} sm={6}>
                                        <MuiPickersUtilsProvider utils={DateFnsUtils}>
                                            <KeyboardDatePicker
                                                disableToolbar
                                                variant="inline"
                                                id="date-picker-inline"
                                                name="foundationDate"
                                                inputVariant="outlined"
                                                fullWidth
                                                disabled={disableField}
                                                label="Дата заснування"
                                                format="dd/MM/yyyy"
                                                value={moment(values.foundationDate).isValid() ? moment(values.foundationDate) : new Date()}
                                                InputAdornmentProps={{ position: "start" }}
                                                onChange={handleDateChange}
                                                error={touched.foundationDate && Boolean(errors.foundationDate)}
                                                helperText={touched.foundationDate && errors.foundationDate}
                                            />
                                        </MuiPickersUtilsProvider>
                                    </Grid>
                                    <Grid item xs={12} sm={6}>
                                        <TextField
                                            onChange={handleFieldChange}
                                            name="countryCode"
                                            variant="outlined"
                                            value={values.countryCode}
                                            label="Код країни"
                                            disabled={disableField}
                                            fullWidth
                                            error={touched.countryCode && Boolean(errors.countryCode)}
                                            helperText={touched.countryCode && errors.countryCode}

                                        />
                                    </Grid>
                                    <Grid item xs={12} sm={6}>
                                        <FormControl variant="outlined" fullWidth>
                                            <InputLabel style={{ marginTop: '-0.5em' }} htmlFor="genreId">Жанр</InputLabel>
                                            <Select
                                                native
                                                id="genreId"
                                                name="genreId"
                                                value={values.genreId ? values.genreId : genres[0].id}
                                                onChange={handleFieldChange}
                                                fullWidth
                                                disabled={disableField}
                                            >
                                                {genres.map(genre => {
                                                    return <option key={genre.name} value={genre.id}>{genre.name}</option>
                                                })}
                                            </Select>
                                        </FormControl>
                                    </Grid>
                                    <Grid item xs={12}>
                                        <TextField
                                            onChange={handleFieldChange}
                                            name="description"
                                            label="Опис"
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
                        items={bands}
                        onClickCreate={handleClickCreate}
                        onClickEdit={handleClickEdit}
                        onClickDelete={handleClickDelete}
                        onClickItem={handleBandItemClick}
                    />
                )
            }
            </div>) : (
                <div className={styles.mediaContainer}>
                    {bands.map(band => {
                        return <BandCard
                            key={band.id}
                            name={band.name}
                            image={band.image}
                            foundationDate={band.foundationDate}
                            countryCode={band.countryCode}
                            description={band.description}
                            onClick={() => handleBandItemClick(band)}
                            id={band.id}
                        >
                        </BandCard>
                    })}

                </div>)}

        </div >
    );
}
export default Band;