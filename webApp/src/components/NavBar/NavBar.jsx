import React, { useEffect, useState } from "react";
import { useTheme } from "@material-ui/core/styles";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import IconButton from "@material-ui/core/IconButton";
import MenuIcon from "@material-ui/icons/Menu";
import MenuItem from "@material-ui/core/MenuItem";
import Menu from "@material-ui/core/Menu";
import Button from "@material-ui/core/Button";
import useMediaQuery from "@material-ui/core/useMediaQuery";
import { withRouter } from "react-router";
import useStyles from "./NavBar.styles"
import PersonIcon from '@material-ui/icons/Person';
import ExitToAppIcon from '@material-ui/icons/ExitToApp';
import Avatar from '@material-ui/core/Avatar';
import * as Constants from 'constants/constants';
import { Link } from 'react-router-dom';
import AuthenticationService from '../AuthenticationService'
import CssBaseline from '@material-ui/core/CssBaseline';
import { getUser, DeleteUser } from 'redux/reducers/user-reducer'
import { connect } from "react-redux";
import { compose } from 'redux'
const logo = Constants.LOGO;

const NavBar = props => {

    const classes = useStyles();

    const [auth, setAuth] = useState(false);
    const [loading, setLoading] = useState(true);
    const [anchorEl, setAnchorEl] = useState(null);
    const open = Boolean(anchorEl);
    const theme = useTheme();
    const isMobile = useMediaQuery(theme.breakpoints.down("xs"));
    const [user, setUser] = useState(null);

    useEffect(() => {
        AuthenticationService.checkAuthenticated().then(data => { setAuth(data) })
        AuthenticationService.getUserInfo().then(data => { setUser(data) })
        
        setLoading(false);
    }, []);

    const handleMenu = event => {
        setAnchorEl(event.currentTarget);
    };

    const handleSignOutClick = () => {
        AuthenticationService.signout();
        setAuth(false);
        props.history.push('/SignIn');
    }

    return (
        <CssBaseline>
            <AppBar position="static" className={classes.root}>
                {!loading && (
                    <Toolbar>
                        <Avatar className={classes.avatar} src={logo} />
                        <Typography variant="h6" className={classes.title}>
                            DP_Music
                    </Typography>
                        {isMobile ? (
                            <div>
                                <IconButton
                                    edge="start"
                                    className={classes.menuButton}
                                    color="inherit"
                                    aria-label="menu"
                                    onClick={handleMenu}
                                >
                                    <MenuIcon />
                                </IconButton>
                                <Menu
                                    id="menu-appbar"
                                    anchorEl={anchorEl}
                                    anchorOrigin={{
                                        vertical: "top",
                                        horizontal: "right"
                                    }}
                                    keepMounted
                                    transformOrigin={{
                                        vertical: "top",
                                        horizontal: "right"
                                    }}
                                    open={open}
                                    onClose={() => setAnchorEl(null)}
                                >
                                    {auth ? (
                                        <div>
                                            <MenuItem >{user && user.login}</MenuItem>
                                            <MenuItem onClick={handleSignOutClick}>Вихідt</MenuItem>

                                        </div>
                                    ) : (
                                        <div>
                                            <MenuItem component={Link} to="/SignIn">Увійти</MenuItem>
                                            <MenuItem component={Link} to="/SignUp" >Реєстрація</MenuItem>
                                        </div>
                                    )}

                                </Menu>
                            </div>
                        ) : (
                            <div className={classes.headerOptions}>
                                {auth ? (
                                    <div className={classes.menuButtonMargin}>
                                        <Button
                                            variant="text"
                                            className={classes.menuButton}

                                        >
                                           {user && user.login}
                                        </Button>
                                        <Button
                                            variant="text"
                                            className={classes.menuButton}
                                            endIcon={<ExitToAppIcon />}
                                            onClick={handleSignOutClick}
                                        >
                                            Вихід
                                     </Button>


                                    </div>
                                ) : (
                                    <div className={classes.menuButtonMargin}>
                                        <Button
                                            component={Link} to="/SignIn"
                                            variant="text"
                                            className={classes.menuButton}
                                        >
                                            Увійти
                                     </Button>
                                        <Button
                                            component={Link} to="/SignUp"
                                            variant="text"
                                            className={classes.menuButton}
                                        >
                                            Реєстрація
                                     </Button>

                                    </div>
                                )}
                            </div>
                        )}
                    </Toolbar>
                )}
            </AppBar>
        </CssBaseline>
    );
}
const mapStateToProps = state => {
    return {

    };
};
export default compose(
    connect(mapStateToProps, { DeleteUser, getUser }),
    withRouter,
)(NavBar);