--
-- PostgreSQL database dump
--

-- Dumped from database version 14.7
-- Dumped by pg_dump version 14.7

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: data; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.data (
    symbol text NOT NULL,
    id smallint NOT NULL,
    lastchange double precision,
    "time" text
);


ALTER TABLE public.data OWNER TO postgres;

--
-- Name: user_data; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.user_data (
    id smallint NOT NULL,
    login text NOT NULL,
    password text NOT NULL,
    is_admin boolean NOT NULL,
    vip_key text
);


ALTER TABLE public.user_data OWNER TO postgres;

--
-- Data for Name: data; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.data (symbol, id, lastchange, "time") FROM stdin;
BTC	1	\N	\N
AAPL	2	175.5	5/27/2023 6:20:01 PM
TSLA	3	194	5/27/2023 6:20:01 PM
META	4	263.75	5/27/2023 6:20:01 PM
AMZN	5	\N	\N
\.


--
-- Data for Name: user_data; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.user_data (id, login, password, is_admin, vip_key) FROM stdin;
1	fimi	fimip	t	\N
2	piro	pirop	t	\N
3	vip	vipp\n	f	fa024kfm4$#
\.


--
-- Name: data data_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.data
    ADD CONSTRAINT data_pkey PRIMARY KEY (id);


--
-- Name: user_data user_data_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_data
    ADD CONSTRAINT user_data_pkey PRIMARY KEY (id);


--
-- PostgreSQL database dump complete
--

