import React, { useState } from "react";
import useStyles from './../MainAdminMenu/MainAdminMenu.styles';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import { nanoid } from 'nanoid'

const MainAdminMenu = props => {
    const classes = useStyles()
    return (
        <div className={classes.main}>
            <Button variant="contained" color="primary" className={classes.buttonCreate} onClick={props.onClickCreate}>
                Додати
                         </Button>
            {!props.items.length ? (<div className={classes.arrayEmpty}>Список пустий</div>) : (<div>{props.items.map(item => {
                const key = nanoid();
                return <Grid container spacing={3} key={key} className={classes.root}>
                    <Grid item xs={12} sm={8}  >
                        <Button className={classes.listItem} variant="outlined" fullWidth onClick={() => { props.onClickItem(item) }} >{item.name}  </Button>
                    </Grid>
                    <Grid item xs={6} sm={2} >
                        <Button color="primary" variant="contained" className={classes.buttonEdit} onClick={() => { props.onClickEdit(item) }}>
                            Змінити
                                    </Button>
                    </Grid>
                    <Grid item xs={6} sm={2} >
                        <Button color="secondary" variant="contained" className={classes.buttonDelete} onClick={() => { props.onClickDelete(item) }}>
                            Видалити
                                    </Button>
                    </Grid>
                </Grid>

            })}</div>)}
        </div>
    )

}
export default MainAdminMenu;

