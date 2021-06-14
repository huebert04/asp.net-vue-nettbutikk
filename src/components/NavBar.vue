<template>
  <v-card>
    <v-toolbar dense>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
    </v-toolbar>

    <v-navigation-drawer :clipped="clipped" v-model="drawer" enable-resize-watcher app dark class="lighten-3">
      <v-list nav dense>
        <v-list-item-group v-model="group">
        <v-list-item v-for="item in listItems" :key="item.title" :to="item.path">
          <v-list-item-action><v-icon>{{ item.icon }}</v-icon></v-list-item-action>
          <v-list-item-content>{{item.title}}</v-list-item-content>
        </v-list-item>
        </v-list-item-group>
      </v-list>
    </v-navigation-drawer>
  </v-card>
</template>

<script>
export default {
    name: 'NavBar',
    data() {
      return {
        drawer: true,
        group: true,
        name: 'Vue SPA Nettbutikk',
        clipped: false,
        listItems: [
          {title: 'Home', path: '/', icon: 'home'},
          {title: 'Products', path: '/products', icon: 'inventory_2'}
        ]
      }
    },
    watch: {
      drawer(value) {
        return value;
      }
    }
}
</script>

<style>
</style>